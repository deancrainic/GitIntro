import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';
import { PropertyService } from 'src/app/services/PropertyService';
import { IProperty } from '../models/property';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.css']
})
export class PropertyComponent implements OnInit {

  id!: number;
  property: any;

  constructor(private route: ActivatedRoute, private propertyService: PropertyService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
    });

    this.propertyService.getProperty(this.id).subscribe(x => this.property = x);
  }
}
