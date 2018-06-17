import { Component, OnInit } from '@angular/core';
import { HomeModel } from './homeModel';
import { HomeService } from '../../services/home/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  model: HomeModel;

  constructor(private service: HomeService) { }

  ngOnInit(): void {
    this.service.getHomeData().subscribe(model => this.model = model);
  }
}
