import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { MatButtonModule, MatMenuModule, MatIconModule, MatNativeDateModule } from '@angular/material';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTooltipModule } from '@angular/material/tooltip';

import { TaskService } from '../services/task/task.service';
import { TaskStatusService } from '../services/task/task-status.service';
import { TasksComponent } from './tasks/tasks.component';
import { TaskCardComponent } from './tasks/task-card/task-card.component';
import { DeleteDialogComponent } from './shared/delete-dialog/delete-dialog.component';

import { HomeService } from '../services/home/home.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TasksComponent,
    TaskCardComponent,
    DeleteDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'tasks', component: TasksComponent }
    ]),
    MatButtonModule, MatMenuModule, MatIconModule, MatToolbarModule, MatSidenavModule, MatListModule, MatSelectModule,
    MatTableModule, MatPaginatorModule, MatDialogModule, MatInputModule, MatFormFieldModule, MatDatepickerModule, MatNativeDateModule, MatCardModule,
    MatExpansionModule, MatTooltipModule
  ],
  entryComponents: [TaskCardComponent, DeleteDialogComponent],
  providers: [TaskService, TaskStatusService, HomeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
