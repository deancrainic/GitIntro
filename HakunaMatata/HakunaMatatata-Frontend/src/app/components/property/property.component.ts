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

  currentUser!:IUser;
  currentProperty!:IProperty;
  propertyViewModel = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    address: new FormControl('', [Validators.required]),
    maxGuests: new FormControl('', [Validators.required]),
    price: new FormControl('', Validators.required)
  });

  constructor(private api: ApiService) { }

  ngOnInit(): void {
    this.api.getCurrentUser().subscribe(x => {
      this.currentUser = x;
      if (this.currentUser.property != null || this.currentUser.property != undefined) {
        this.api.getPropertyById(this.currentUser.property.propertyId).subscribe(p => {
          this.currentProperty = p;

          this.propertyViewModel.controls['name'].setValue(this.currentProperty.name);
          this.propertyViewModel.controls['description'].setValue(this.currentProperty.description);
          this.propertyViewModel.controls['address'].setValue(this.currentProperty.address);
          this.propertyViewModel.controls['maxGuests'].setValue(this.currentProperty.maxGuests);
          this.propertyViewModel.controls['price'].setValue(this.currentProperty.price);
        });
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
    this.api.addProperty(createdProperty).subscribe(res => { this.ngOnInit(); }, err => console.log('wrong'));
  }

  deleteProperty(): void {
    this.api.deleteProperty().subscribe(res => { this.ngOnInit(); }, err => console.log('wrong'));
  }
}
