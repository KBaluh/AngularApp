import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HomeModel } from '../../app/home/homeModel';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  getHomeData(): Observable<HomeModel> {
    return this.http.get<HomeModel>("/api/Home/GetHomeData");
  }
}
