import { Component, OnInit, Input } from '@angular/core';
import { TaskTimeService } from '../../../services/task/task-time.service';
import { TaskTimeModel } from '../task-time-model';
import { Observable } from 'rxjs';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-task-time',
  templateUrl: './task-time.component.html',
  styleUrls: ['./task-time.component.css']
})
export class TaskTimeComponent implements OnInit {

  @Input() taskModelId: number;
  @Input() totalTime: number;

  dataSource: MatTableDataSource<TaskTimeModel>;
  columnsToDisplay = ['taskTimeId', 'startDate', 'endDate', 'minutes', 'actions'];

  displayIcon: string;
  iconState: IconState;

  constructor(private service: TaskTimeService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData(): void {
    console.log("Start task time for task id: ", this.taskModelId);
    this.service.getByTask(this.taskModelId).subscribe(result => {
      this.dataSource = new MatTableDataSource(result);
      this.updateTotal(result);
      this.updateIconState();
    });
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

  calcMinutes(startDate: Date, endDate?: Date): number {
    if (endDate == null) {
      return 0;
    }
    startDate = new Date(startDate);
    endDate = new Date(endDate);
    let diff = Math.abs(endDate.getTime() - startDate.getTime());
    let minutes = Math.floor((diff / 1000) / 60);
    return minutes;
  }

  updateTotal(data: TaskTimeModel[]): void {
    let total = 0;
    for (let i = 0; i < data.length; i++) {
      total += data[i].minutes;
    }
    this.totalTime = total;
  }
}

enum IconState {
  Play = "play_arrow",
  Stop = "stop"
}
