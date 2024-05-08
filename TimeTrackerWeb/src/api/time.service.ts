import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskViewModel } from 'src/viewModel/taskViewModel';

@Injectable({
  providedIn: 'root'
})
export class TimeService {
  public basePath: string = 'https://localhost:44311/api';

  constructor(private httpClient: HttpClient) { 
  }

  public GetCurrentTimeTask() : Observable<TaskViewModel[]> {
    return this.httpClient.get<TaskViewModel[]>(`${this.basePath}/Time/GetCurrentTimeByTasks`);
  }
}
