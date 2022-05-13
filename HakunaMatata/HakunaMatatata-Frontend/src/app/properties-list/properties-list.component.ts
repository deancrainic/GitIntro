import { Component, Input, OnInit } from '@angular/core';
import { IProperty } from '../models/property';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-properties-list',
  templateUrl: './properties-list.component.html',
  styleUrls: ['./properties-list.component.css']
})
export class PropertiesListComponent implements OnInit {

  properties!: IProperty[];
  @Input()
  location!: string;
  @Input()
  checkin!: Date;
  @Input()
  checkout!: Date;
  @Input()
  guests!: number;
  shownProperties!: IProperty[];

  constructor(private api: ApiService) { }

  ngOnInit(): void {
    this.api.getAllProperties().subscribe(x => {
      this.properties = x;
      this.shownProperties = x.filter(property => property.address.includes(this.location));
    });
  }

  doThis(): void {
    console.log(this.properties);
  }
}
