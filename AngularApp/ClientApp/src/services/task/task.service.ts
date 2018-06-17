import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { TaskModel } from '../../app/tasks/taskModel';
import { TaskListModel } from '../../app/tasks/taskListModel';
import 'rxjs/add/operator/map';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private baseUrl: string = "/api/Task/";

  constructor(private http: HttpClient) { }

  getTasks(): Observable<TaskListModel[]> {
    return this.http.get<TaskListModel[]>(this.baseUrl + "GetAll");
  }

  getActive(): Observable<TaskListModel[]> {
    return this.http.get<TaskListModel[]>(this.baseUrl + "GetActive");
  }

  getTask(id: number): Observable<TaskModel> {
    return this.http.get<TaskModel>(this.baseUrl + "GetById?id=" + id);
  }

  appendTask(model: TaskModel): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'/*,
        'Authorization': 'my-auth-token'*/
      })
    };
    return this.http.post<TaskModel>(this.baseUrl + "Append", model, httpOptions);
  }

  updateTask(model: TaskModel): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'/*,
        'Authorization': 'my-auth-token'*/
      })
    };
    return this.http.post<TaskModel>(this.baseUrl + "Update", model, httpOptions);
  }

  removeById(id: number): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'/*,
        'Authorization': 'my-auth-token'*/
      })
    };
    return this.http.post(this.baseUrl + "RemoveById?id=" + id, httpOptions);
  }
}
