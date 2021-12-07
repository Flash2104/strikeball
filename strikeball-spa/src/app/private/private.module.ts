import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatListModule} from '@angular/material/list';
import {MatSidenavModule} from '@angular/material/sidenav';
import {RouterModule, Routes} from '@angular/router';
import {SharedModule} from '../shared/shared.module';
import {СommandContainerComponent} from './command/command-container.component';
import {ProfileContainerComponent} from './profile/profile-container.component';
import {SideNavContainerComponent} from './sidenav-container.component';
import {MatDividerModule} from '@angular/material/divider';
import {MatTableModule} from '@angular/material/table';
import {ProfileEditComponent} from './profile/edit/profile-edit.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {path: '*', redirectTo: '/', pathMatch: 'full'},
      {
        path: '',
        component: SideNavContainerComponent,
        children: [
          {path: '', redirectTo: 'profile', pathMatch: 'full'},
          {
            path: 'profile',
            component: ProfileContainerComponent,
            // children: [
            //   // {path: '', redirectTo: '/profile/edit', pathMatch: 'full'},
            //   {path: 'edit', component: ProfileEditComponent},
            // ]
          },
          {
            path: 'profile/edit',
            component: ProfileEditComponent,
          },
          {
            path: 'command',
            component: СommandContainerComponent,
          },
          {
            path: 'events',
            component: СommandContainerComponent,
          },
        ],
      },
    ],
  },
];

@NgModule({
  declarations: [
    SideNavContainerComponent,
    ProfileContainerComponent,
    СommandContainerComponent,
    ProfileEditComponent
  ],
  imports: [
    MatButtonModule,
    MatSidenavModule,
    MatGridListModule,
    MatCardModule,
    MatListModule,
    MatIconModule,
    CommonModule,
    MatTableModule,
    MatInputModule,
    FormsModule,
    MatDividerModule,
    ReactiveFormsModule,
    SharedModule,
    RouterModule.forChild(routes),
  ],
})
export class PrivateModule {
}
