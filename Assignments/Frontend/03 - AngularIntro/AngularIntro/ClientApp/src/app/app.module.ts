import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './home/welcome/welcome.component';
import { PropertyModule } from './properties/property.module';
import { UserComponent } from './users/user/user.component';
import { UserReactiveFormComponent } from './users/user-reactive-form/user-reactive-form.component';
import { PropertyService } from './services/PropertyService';
import { ImageService } from './services/imagesService';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    UserComponent,
    UserReactiveFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PropertyModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    PropertyService,
    ImageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
