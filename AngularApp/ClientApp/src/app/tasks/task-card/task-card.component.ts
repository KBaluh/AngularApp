import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { TaskModel } from '../taskModel';
import { TaskService } from '../../../services/task/task.service';
import { debug } from 'util';

@Component({
  selector: 'app-task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.css']
})
export class TaskCardComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<TaskCardComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TaskModel,
    private service: TaskService
  ) { }

  ngOnInit() {
  }

  saveData(): void {
    this.service.appendTask(this.data).subscribe(result => this.dialogRef.close());
  }
}
