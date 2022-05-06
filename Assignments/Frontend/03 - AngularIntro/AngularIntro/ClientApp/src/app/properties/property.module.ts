import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PropertiesListComponent } from './properties-list/properties-list.component';
import { PropertyImageComponent } from './property-image/property-image.component';
import { FormsModule } from '@angular/forms';
import { ScalePricePipe } from '../pipes/ScalePricePipe';

@NgModule({
  declarations: [
    PropertiesListComponent,
    PropertyImageComponent,
    ScalePricePipe
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class PropertyModule { }
