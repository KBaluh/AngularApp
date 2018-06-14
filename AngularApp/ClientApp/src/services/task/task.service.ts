import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { TaskModel } from '../../app/tasks/taskModel';
import 'rxjs/add/operator/map';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private baseUrl: string = "/api/Task/";

  constructor(private http: HttpClient) { }

  getTasks(): Observable<TaskModel[]> {
    return this.http.get<TaskModel[]>(this.baseUrl + "GetAll");
  }
}
