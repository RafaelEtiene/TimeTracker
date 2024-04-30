import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Subscription, interval } from 'rxjs';
import { TaskViewModel } from 'src/viewModel/taskViewModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  ngOnInit(): void {
    this.taskSelected = this.lsTasks[0];
  }

    public lsTasks: TaskViewModel[] = [
    {
      idTask: 1,
      nameTask: 'Ajuste na validação',
      time: 0
    },
    {
      idTask: 2,
      nameTask: 'Criação de novo btn',
      time: 0
    }
  ];

  public taskSelected: TaskViewModel = null!;
  private timerSubscription: Subscription = new Subscription;
  public time: number = 0;
  public timerRunning: boolean = false;

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
      task.time++;
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
      currentTask.time = task.time;
    }
  }
  private padZero(value: number): string {
    return value < 10 ? `0${value}` : `${value}`;
  }
}