import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { IProperty } from '../models/property';
import { PropertyImageComponent } from '../property-image/property-image.component';

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
      propertyId : 1,
      propertyName : "Sunset Villa",
      propertyDescription : "Big villa near the beach",
      maxGuests : 12,
      price: 6400,
      imageUrl : "https://media.gettyimages.com/photos/luxury-apartment-with-private-pool-picture-id1198357646?s=612x612"
    },
    {
      propertyId : 2,
      propertyName : "Log Cabin",
      propertyDescription : "Log Cabin in the woods, pitoresque view",
      maxGuests : 10,
      price: 4600,
      imageUrl : "https://www.christiesrealestate.com/blog/wp-content/uploads/2021/12/aerial-18-1.jpg"
    },
    {
      propertyId : 3,
      propertyName : "zCozy Apartment",
      propertyDescription : "Cozy apartment near city center",
      maxGuests : 4,
      price: 1500,
      imageUrl : "https://images1.apartments.com/i2/uo03K21lP2hkPLvhuXSC8OBGAylS5QwLB7oX7gjjlaY/111/the-apartments-at-citycenter-washington-dc-primary-photo.jpg"
    }
  ];

  constructor() { }

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  performSort(): void {
    if (this.sortBy == 'price') {
      this.propertiesList.sort((a, b) => a.price > b.price ? 1 : -1);
      this.pageTitle = `Properties list sorted by ${this.sortBy}`;
    }
    else if (this.sortBy == 'name') {
      this.propertiesList.sort((a, b) => a.propertyName > b.propertyName ? 1 : -1);
      this.pageTitle = `Properties list sorted by ${this.sortBy}`;
    }
    else 
      this.pageTitle = `Properties list can't sorted by ${this.sortBy}`;
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    console.log(this.image);
}

  imgUrl($event:string) {
    console.log($event);
  }
}
