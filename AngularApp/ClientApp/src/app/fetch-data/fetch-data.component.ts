import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatPaginator } from '@angular/material';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})
export class FetchDataComponent implements OnInit {
  private url: string;

  // Table columns to display
  columnsToDisplay = ['temperatureC', 'temperatureF', 'dateFormatted', 'summary'];

  @ViewChild(MatPaginator) weatherPaginator: MatPaginator;
  dataSource: MatTableDataSource<WeatherForecast>;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'api/SampleData/WeatherForecasts';
  }

  ngOnInit() {
    this.loadWeather();
  }

  loadWeather(): void {
    this.http.get<WeatherForecast[]>(this.url).subscribe(result => {
      this.dataSource = new MatTableDataSource(result);
      this.dataSource.paginator = this.weatherPaginator;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
