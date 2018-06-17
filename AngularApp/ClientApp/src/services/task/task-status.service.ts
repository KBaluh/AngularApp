import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskStatusModel } from '../../app/tasks/taskStatusModel';

@Injectable({
  providedIn: 'root'
})
export class TaskStatusService {
  private baseUrl: string = "/api/TaskStatusModels/";

  constructor(private http: HttpClient) { }

  getAll(): Observable<TaskStatusModel[]> {
    return this.http.get<TaskStatusModel[]>(this.baseUrl);
  }

  getById(id: number): Observable<TaskStatusModel> {
    return this.http.get<TaskStatusModel>(this.baseUrl + id);
  }
}
