import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Subscription, interval } from 'rxjs';
import { TimeService } from 'src/api/time.service';
import { TaskViewModel } from 'src/viewModel/taskViewModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private _timeService: TimeService) {
  }

  ngOnInit(): void {
    this.getCurrentTimeTask();
    this.taskSelected = this.lsTasks[0];
  }

  public lsTasks: TaskViewModel[] = [];

  public taskSelected: TaskViewModel = null!;
  private timerSubscription: Subscription = new Subscription;
  public time: number = 0;
  public timerRunning: boolean = false;

  getCurrentTimeTask() {
    debugger;
    this._timeService.GetCurrentTimeTask()
      .subscribe(r => {
        //this.lsTasks = r;
        console.log(r);
        console.log(this.lsTasks);
      })
  }
  startPauseTimer(taskSelected: TaskViewModel) {
    var btnStartPause = document.querySelector('#btnStartPause');
    var circle = document.getElementById('circle-start');
    if(btnStartPause !== null && circle !== null){
      if(this.timerRunning){
        btnStartPause.className = 'fa fa-play fa-2x';
        circle.style.backgroundColor = 'rgb(49, 255, 100)';
        this.pauseTimer();
      }
      else {
        btnStartPause.className = 'fa fa-pause fa-2x';
        circle.style.backgroundColor = 'red';
        this.startTimer(taskSelected);
      }
    }
  }

  startTimer(task: TaskViewModel) {
    this.timerRunning = true;
    this.timerSubscription = interval(1000).subscribe(() => {
      task.totalTime++;
    });
  }

  pauseTimer() {
    this.timerRunning = false;
    if (this.timerSubscription) {
      this.timerSubscription.unsubscribe();
    }
    if(this.taskSelected){
      this.updateTime(this.taskSelected);
    }
  }

  formatTime(time: number) {
    const hours = Math.floor(time / 3600);
    const minutes = Math.floor((time % 3600) / 60);
    const seconds = time % 60;

    return `${this.padZero(hours)}:${this.padZero(minutes)}:${this.padZero(seconds)}`;
  }

  selectTask(idTask: number){
    let objTask = this.lsTasks.find(e => e.idTask == idTask);
    if(objTask){
      this.taskSelected = objTask;
    }
  }

  updateTime(task: TaskViewModel){
    let currentTask = this.lsTasks.find(e => e.idTask == task.idTask);
    if(currentTask){
      currentTask.totalTime = task.totalTime;
    }
  }
  private padZero(value: number): string {
    return value < 10 ? `0${value}` : `${value}`;
  }
}