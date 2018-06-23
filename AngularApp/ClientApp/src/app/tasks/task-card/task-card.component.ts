import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { TaskModel } from '../taskModel';
import { TaskService } from '../../../services/task/task.service';
import { debug } from 'util';
import { TaskStatusService } from '../../../services/task/task-status.service';
import { TaskStatusModel } from '../taskStatusModel';

@Component({
  selector: 'app-task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.css']
})
export class TaskCardComponent implements OnInit {

  action: string;
  model: TaskModel;

  statuses: TaskStatusModel[];

  constructor(
    public dialogRef: MatDialogRef<TaskCardComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { action: string, model: TaskModel },
    private service: TaskService, private statusService: TaskStatusService)
  {
    this.action = data.action;
    this.model = data.model;
    if (this.model == null) {
      this.model = new TaskModel();
      this.model.createdDate = new Date();
      this.model.startDate = new Date();
      let endDate = new Date();
      endDate.setDate(endDate.getDate() + 1);
      this.model.endDate = endDate;
      this.model.taskStatusModelId = 1;
    }
  }

  ngOnInit() {
    this.statusService.getAll().subscribe(result => this.statuses = result);
  }

  saveData(): void {
    if (this.action === "APPEND") {
      this.service.appendTask(this.model).subscribe(result => this.dialogRef.close());
    } else if (this.action === "EDIT") {
      this.service.updateTask(this.model).subscribe(result => this.dialogRef.close());
    } else {
      console.error("task-card.component: No action detected");
      this.dialogRef.close();
    }
  }
}

