import { Component, OnInit, ViewChild } from '@angular/core';
import { TaskService } from '../../services/task/task.service';
import { TaskModel } from './taskModel';
import { MatTableDataSource, MatPaginator, MatDialog, MatButton } from '@angular/material';
import { TaskCardComponent } from './task-card/task-card.component';
import { DeleteDialogComponent } from '../shared/delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  dateFormat: "dd.MM.yy hh:mm:ss";
  dataSource: MatTableDataSource<TaskModel>;
  columnsToDisplay = ['taskModelId', 'title', 'startDate', 'endDate', 'createdDate', 'status', 'actions'];

  @ViewChild(MatPaginator) taskPaginator: MatPaginator;

  constructor(private service: TaskService, public dialog: MatDialog) { }

  ngOnInit() {
    this.loadData();
  }

  loadData(): void {
    this.service.getTasks().subscribe(result => {
      console.log("task list: ", result);
      this.dataSource = new MatTableDataSource(result);
      this.dataSource.paginator = this.taskPaginator;
    });
  }

  append(): void {
    let endDate = new Date();
    endDate.setDate(endDate.getDate() + 1);
    let emptyData: TaskModel = { body: '', createdDate: new Date(), startDate: new Date(), endDate: endDate, taskModelId: 0, title: '', userId: 0, taskStatusModelId: 1, taskStatusModels: null };
    this.openEditDialog(emptyData, "APPEND");
  }

  editTask(id: number): void {
    this.service.getTask(id).subscribe(result => {
      console.log("EditTask:" + id, result);
      this.openEditDialog(result, "EDIT");
    });
  }

  deleteTask(id: number): void {
    this.service.getTask(id).subscribe(task => {
      let title = "by id: " + task.taskModelId;
      let text = "Task: " + task.title;
      let dialogRef = this.dialog.open(DeleteDialogComponent, {
        width: "300px",
        data: { title: title, text: text }
      });
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          //console.log("Delete confirm: true");
          this.service.removeById(id).subscribe(delResult => {
            //console.log("Delete successul. id: " + id);
            this.loadData();
          });
        }
      });
    });
  }

  openEditDialog(model: TaskModel, action: string) {
    let dialogRef = this.dialog.open(TaskCardComponent, {
      width: '50vw',
      //height: '80vh',
      data: { action: action, model: model }
    });
    dialogRef.afterClosed().subscribe(result => {
      this.loadData();
    });
  }
}
