import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskTimeModel } from '../../app/tasks/task-time-model';
import { TaskModel } from '../../app/tasks/taskModel';

@Injectable({
  providedIn: 'root'
})
export class TaskTimeService {
  private baseUrl = '/api/TaskTime/';

  constructor(private http: HttpClient) { }

  getByTask(taskModelId: number): Observable<TaskTimeModel[]> {
    return this.http.get<TaskTimeModel[]>(this.baseUrl + taskModelId);
  }

  removeById(taskTimeId: number): Observable<any> {
    return this.http.delete<TaskTimeModel>(this.baseUrl + taskTimeId);
  }

  update(model: TaskTimeModel): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'/*,
        'Authorization': 'my-auth-token'*/
      })
    };
    return this.http.put<TaskTimeModel>(this.baseUrl + model.taskModelId, model, httpOptions);
  }
}
