import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

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

  @Output()
  sendDataEvent: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  //show img url in console from event
  getImgUrl():void {
    this.sendDataEvent.emit(this.imageUrl);
  }

  //show img url string in console with @viewChild
  getImgUrlString(): string {
    return this.imageUrl;
  }
}
