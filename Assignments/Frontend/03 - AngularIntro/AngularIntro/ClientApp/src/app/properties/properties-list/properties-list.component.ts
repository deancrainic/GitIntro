import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { IImage } from 'src/app/image/image';
import { PropertyService } from 'src/app/services/PropertyService';
import { IProperty } from '../models/property';
import { PropertyImageComponent } from '../property-image/property-image.component';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-properties-list',
  templateUrl: './properties-list.component.html',
  styleUrls: ['./properties-list.component.css']
})
export class PropertiesListComponent implements OnInit, AfterViewInit {

  pageTitle = 'Properties List';
  showImage = true;
  sortBy = 'name';
  percentage = 12;

  @ViewChild('image') image!: PropertyImageComponent;

  propertiesList: IProperty[] = [
    {
      propertyId: 1,
      name: "Sunset Villa",
      description: "Big villa near the beach",
      address: "Mamaia, Romania",
      maxGuests: 12,
      price: 6400,
      imageUrl: "https://media.gettyimages.com/photos/luxury-apartment-with-private-pool-picture-id1198357646?s=612x612"
    },
    {
      propertyId: 2,
      name: "Log Cabin",
      description: "Log Cabin in the woods, pitoresque view",
      address: "Poiana Brasov, Romania",
      maxGuests: 10,
      price: 4600,
      imageUrl: "https://www.christiesrealestate.com/blog/wp-content/uploads/2021/12/aerial-18-1.jpg"
    },
    {
      propertyId: 3,
      name: "zCozy Apartment",
      description: "Cozy apartment near city center",
      address: "Timisoara, Romania",
      maxGuests: 4,
      price: 1500,
      imageUrl: "https://images1.apartments.com/i2/uo03K21lP2hkPLvhuXSC8OBGAylS5QwLB7oX7gjjlaY/111/the-apartments-at-citycenter-washington-dc-primary-photo.jpg"
    }
  ];

  propertiesObs!: Observable<IProperty[]>;

  constructor(private propertyService: PropertyService) { }

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  performSort(): void {
    if (this.sortBy == 'price') {
      this.propertiesList.sort((a, b) => a.price > b.price ? 1 : -1);
      this.pageTitle = `Properties list sorted by ${this.sortBy}`;
    }
    else if (this.sortBy == 'name') {
      this.propertiesList.sort((a, b) => a.name > b.name ? 1 : -1);
      this.pageTitle = `Properties list sorted by ${this.sortBy}`;
    }
    else 
      this.pageTitle = `Properties list can't sorted by ${this.sortBy}`;
  }

  ngOnInit(): void {
    this.propertiesObs = this.propertyService.getProperties();
}

  ngAfterViewInit(): void {
    console.log(this.image);
}

  imgUrl($event:string) {
    console.log($event);
  }

  postProperty(): void {
    this.propertyService.postProperty({ 
      name: "testProperty5", description: "empty", address: "idk", maxGuests: 9, price: 256 
    }).subscribe(x => console.log(x));
  }

  img = new IImage();

  addImageToProperty1(): void {
    this.propertyService.postImage({
      name: "pictureFromPropertiesListComponent",
      path: "path_idk"
    }).subscribe(x => this.img = x);
    console.log(this.img);
    
    let newProp = this.propertyService.addImageToProperty(1, this.img.id).subscribe();
    console.log(newProp);
  }
}