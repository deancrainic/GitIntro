import { AfterViewInit, Component, OnInit } from '@angular/core';
import { IProperty } from '../models/property';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-properties-list',
  templateUrl: './properties-list.component.html',
  styleUrls: ['./properties-list.component.css']
})
export class PropertiesListComponent implements OnInit {

  properties!: IProperty[];

  constructor(private api: ApiService) { }

  ngOnInit(): void {
    this.api.getAllProperties().subscribe(x => this.properties = x)
  }

  doThis(): void {
    console.log(console.log(this.properties));
  }
}
