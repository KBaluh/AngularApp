import { Component, OnInit, Input } from '@angular/core';
import { TaskTimeService } from '../../../services/task/task-time.service';
import { TaskTimeModel } from '../task-time-model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-task-time',
  templateUrl: './task-time.component.html',
  styleUrls: ['./task-time.component.css']
})
export class TaskTimeComponent implements OnInit {

  @Input() taskModelId: number;
  data: TaskTimeModel[];

  constructor(private service: TaskTimeService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData(): void {
    console.log("Start task time for task id: ", this.taskModelId);
    this.service.getByTask(this.taskModelId).subscribe(result => this.data = result);
  }

}
