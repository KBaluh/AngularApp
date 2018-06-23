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

  displayIcon: string;
  iconState: IconState;

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
    this.updateIconState();
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

  updateIconState(): void {
    // TODO: Get from service task time is finish or not and set state
    this.iconState = IconState.Play;

    // Set state value for display icon
    this.displayIcon = this.iconState;
  }

  onIconClick(): void {
    if (this.iconState == IconState.Play) {
      this.iconState = IconState.Stop;
    } else {
      this.iconState = IconState.Play;
    }
    this.displayIcon = this.iconState;
  }
}

enum IconState {
  Play = "play_arrow",
  Stop = "stop"
}
