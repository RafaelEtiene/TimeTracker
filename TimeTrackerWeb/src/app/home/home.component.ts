import { Component } from '@angular/core';
import { BehaviorSubject, Subscription, interval } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  private timerSubscription: Subscription = new Subscription;
  time: number = 0;
  timerRunning: boolean = false;

  startPauseTimer() {
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
        this.startTimer();
      }
    }
  }

  startTimer() {
    this.timerRunning = true;
    this.timerSubscription = interval(1000).subscribe(() => {
      this.time++;
    });
  }

  pauseTimer() {
    this.timerRunning = false;
    if (this.timerSubscription) {
      this.timerSubscription.unsubscribe();
    }
  }
  formatTime() {
    const hours = Math.floor(this.time / 3600);
    const minutes = Math.floor((this.time % 3600) / 60);
    const seconds = this.time % 60;

    return `${this.padZero(hours)}:${this.padZero(minutes)}:${this.padZero(seconds)}`;
  }

  private padZero(value: number): string {
    return value < 10 ? `0${value}` : `${value}`;
  }
}