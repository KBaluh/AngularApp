import { Component, OnInit, ViewChild } from '@angular/core';
import { TaskService } from '../../services/task/task.service';
import { TaskModel } from './taskModel';
import { MatTableDataSource, MatPaginator, MatDialog } from '@angular/material';
import { TaskCardComponent } from './task-card/task-card.component';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  dateFormat: "dd.MM.yy hh:mm:ss";
  dataSource: MatTableDataSource<TaskModel>;
  columnsToDisplay = ['taskModelId', 'title', 'startDate', 'endDate', 'createdDate'];

  @ViewChild(MatPaginator) taskPaginator: MatPaginator;

  constructor(private service: TaskService, public dialog: MatDialog) { }

  ngOnInit() {
    this.loadData();
  }

  loadData(): void {
    this.service.getTasks().subscribe(result => {
      this.dataSource = new MatTableDataSource(result);
      this.dataSource.paginator = this.taskPaginator;
    });
  }

  append(): void {
    let endDate = new Date();
    endDate.setDate(endDate.getDate() + 1);
    let emptyData: TaskModel = { body: '', createdDate: new Date(), startDate: new Date(), endDate: endDate, taskModelId: 0, title: '', userId: 0 };
    let dialogRef = this.dialog.open(TaskCardComponent, {
      width: '50vw',
      height: '80vh',
      data: emptyData
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('Dialog result', result);
    });
  }
}
