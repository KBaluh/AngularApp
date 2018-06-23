import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-task-time',
  templateUrl: './task-time.component.html',
  styleUrls: ['./task-time.component.css']
})
export class TaskTimeComponent implements OnInit {

  @Input() taskModelId: number;

  constructor() { }

  ngOnInit() {
  }

}
