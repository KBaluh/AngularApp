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
  links: LinkInfo[];

  constructor(private service: HomeService) { }

  ngOnInit(): void {
    this.service.getHomeData().subscribe(model => this.model = model);
    this.links = [
      { info: 'Material components', link: 'https://material.angular.io/components/categories' },
      { info: 'Material icons', link: 'https://material.io/tools/icons/' },
      { info: 'Angular Update Guide', link: 'https://update.angular.io/' },
      { info: 'Angular Post', link: 'http://www.talkingdotnet.com/angular-post/' }
    ];
  }
}

interface LinkInfo {
  link: string;
  info: string;
}
