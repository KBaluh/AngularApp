import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { TaskModel } from '../taskModel';
import { TaskService } from '../../../services/task/task.service';
import { debug } from 'util';

@Component({
  selector: 'app-task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.css']
})
export class TaskCardComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: TaskModel, private service: TaskService) { }

  ngOnInit() {
  }

  saveData(): void {
    console.log("task-card.saveData");
    this.service.appendTask(this.data).subscribe();
  }
}
