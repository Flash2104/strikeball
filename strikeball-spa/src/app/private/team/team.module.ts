import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { MatTreeModule } from '@angular/material/tree';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { TeamMainInfoEditComponent } from './main-page/edit/team-main-info-edit.component';
import { TeamMainInfoComponent } from './main-page/main-info/team-main-info.component';
import { TeamMainPageComponent } from './main-page/team-main-page.component';
import { TeamRepository } from './repository/team.repository';
import { TeamService } from './repository/team.service';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: '*', redirectTo: '/', pathMatch: 'full' },
      {
        path: '',
        component: TeamMainPageComponent,
        children: [],
      },
    ],
  },
];

@NgModule({
  declarations: [
    TeamMainPageComponent,
    TeamMainInfoComponent,
    TeamMainInfoEditComponent,
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
    MatTreeModule,
    ReactiveFormsModule,
    SharedModule,
    RouterModule.forChild(routes),
  ],
  providers: [TeamService, TeamRepository],
})
export class TeamModule {}
