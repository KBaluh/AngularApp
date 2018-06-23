import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskTimeModel } from '../../app/tasks/task-time-model';

@Injectable({
  providedIn: 'root'
})
export class TaskTimeService {
  private baseUrl = '/api/TaskTime/';

  constructor(private http: HttpClient) { }

  getByTask(taskModelId: number): Observable<TaskTimeModel[]> {
    return this.http.get<TaskTimeModel[]>(this.baseUrl + taskModelId);
  }
}
