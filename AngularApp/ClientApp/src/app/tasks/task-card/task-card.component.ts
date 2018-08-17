import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { TaskModel } from '../taskModel';
import { TaskService } from '../../../services/task/task.service';
import { TaskStatusService } from '../../../services/task/task-status.service';
import { TaskStatusModel } from '../taskStatusModel';

@Component({
  selector: 'app-task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.css']
})
export class TaskCardComponent implements OnInit {
  model: TaskModel = null;
  statuses: TaskStatusModel[];
  action: string;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private service: TaskService,
    private statusService: TaskStatusService) { }

  ngOnInit() {
    this.statusService.getAll().subscribe(result => this.statuses = result);

    let taskId = Number.parseInt(this.activatedRoute.snapshot.paramMap.get('id'));
    if (taskId) {
      // Get by task id
      this.action = "EDIT";
        
      this.service.getTask(taskId).subscribe(result => {
        this.model = result;
      });
    } else {
      // It's new task
      this.action = "APPEND";
        
      this.model = new TaskModel();
      this.model.createdDate = new Date();
      this.model.startDate = new Date();
      let endDate = new Date();
      endDate.setDate(endDate.getDate() + 1);
      this.model.endDate = endDate;
      this.model.taskStatusModelId = 1;
    }
  }

  saveData(): void {
    if (this.action === "APPEND") {
      this.service.appendTask(this.model).subscribe(result => this.close());
    } else if (this.action === "EDIT") {
      this.service.updateTask(this.model).subscribe(result => this.close());
    } else {
      console.error("task-card.component: No action detected");
      this.close();
    }
  }

  close(): void {
    this.router.navigate(['/tasks/']);
  }
}

