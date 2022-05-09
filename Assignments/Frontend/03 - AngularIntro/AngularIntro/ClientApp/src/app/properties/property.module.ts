import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PropertiesListComponent } from './properties-list/properties-list.component';
import { PropertyImageComponent } from './property-image/property-image.component';
import { FormsModule } from '@angular/forms';
import { ScalePricePipe } from '../pipes/ScalePricePipe';
import { PropertyComponent } from './property/property.component';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  declarations: [
    PropertiesListComponent,
    PropertyImageComponent,
    ScalePricePipe,
    PropertyComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    AppRoutingModule
  ]
})
export class PropertyModule { }
