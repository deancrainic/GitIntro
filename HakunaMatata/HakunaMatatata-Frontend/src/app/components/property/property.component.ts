import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IProperty } from 'src/app/models/property';
import { IPropertyCreate } from 'src/app/models/propertyCreate';
import { IUser } from 'src/app/models/user';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.css']
})
export class PropertyComponent implements OnInit {

  currentUser!: IUser;
  currentProperty!: IProperty | null;
  propertyViewModel = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    address: new FormControl('', [Validators.required]),
    maxGuests: new FormControl('', [Validators.required]),
    price: new FormControl('', Validators.required)
  });
  message!: string;

  constructor(private api: ApiService) { }

  ngOnInit(): void {
    this.api.getCurrentUser().subscribe(x => {
      this.currentProperty = x.property;

      if (this.currentProperty != null) {
        this.propertyViewModel.controls['name'].setValue(this.currentProperty.name);
        this.propertyViewModel.controls['description'].setValue(this.currentProperty.description);
        this.propertyViewModel.controls['address'].setValue(this.currentProperty.address);
        this.propertyViewModel.controls['maxGuests'].setValue(this.currentProperty.maxGuests);
        this.propertyViewModel.controls['price'].setValue(this.currentProperty.price);
      } else {
        this.propertyViewModel.reset();
      }
    });
  }

  onSubmit(): void {
    let createdProperty: IPropertyCreate = {
      name: this.propertyViewModel.get('name')?.value,
      description: this.propertyViewModel.get('description')?.value,
      address: this.propertyViewModel.get('address')?.value,
      maxGuests: this.propertyViewModel.get('maxGuests')?.value,
      price: this.propertyViewModel.get('price')?.value,
    };

    if (this.currentProperty == null) {
      this.api.addProperty(createdProperty).subscribe(res => this.message = 'Successfully added', err => console.log('wrong'));
    } else {
      this.api.updateProperty(createdProperty).subscribe(res => this.message = 'Successfully edited', err => console.log(err.error));
    }
  }

  deleteProperty(): void {
    this.api.deleteProperty().subscribe(res => this.ngOnInit(), err => console.log('wrong'));
  }
}
