import { Component, OnInit, ViewChild } from '@angular/core';
import { TaskService } from '../../services/task/task.service';
import { TaskModel } from './taskModel';
import { MatTableDataSource, MatPaginator } from '@angular/material';

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
  
  constructor(private service: TaskService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData(): void {
    this.service.getTasks().subscribe(result => {
      this.dataSource = new MatTableDataSource(result);
      this.dataSource.paginator = this.taskPaginator;
    });
  }
}
