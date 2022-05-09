import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomeComponent } from './home/welcome/welcome.component';
import { PropertiesListComponent } from './properties/properties-list/properties-list.component';
import { PropertyComponent } from './properties/property/property.component';
import { UserReactiveFormComponent } from './users/user-reactive-form/user-reactive-form.component';
import { UserComponent } from './users/user/user.component';

const routes: Routes = [
  {
    path: 'properties',
    component: PropertiesListComponent
  },
  {
    path: 'properties/:id',
    component: PropertyComponent
  },
  {
    path: 'welcome',
    component: WelcomeComponent
  },
  {
    path: 'user',
    component: UserComponent
  },
  {
    path: 'user-reactive-form',
    component: UserReactiveFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
