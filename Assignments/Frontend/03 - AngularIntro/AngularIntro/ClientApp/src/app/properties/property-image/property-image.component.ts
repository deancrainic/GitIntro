import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-property-image',
  templateUrl: './property-image.component.html',
  styleUrls: ['./property-image.component.css']
})
export class PropertyImageComponent implements OnInit {

  imageWidth = 100;
  imageMargin = 2;

  @Input()
  imageUrl!: string;

  constructor() { }

  ngOnInit(): void {
  }

}
