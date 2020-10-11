import { Component, OnInit } from '@angular/core';
import { DogService } from './dog.service';
import { Dog } from './dog';

@Component({
  selector: 'app-dog',
  templateUrl: './dog.component.html',
  styleUrls: ['./dog.component.css']
})
export class DogComponent implements OnInit {

  constructor(private dogService: DogService) { }

  dogs: Dog[];
  name: string;
  age: number;
  dog: Dog = new Dog();

  ngOnInit() {
    this.dogService.get().subscribe(data => {
      this.dogs = data;
    });
  }

  onSubmit() {
    this.dog.name = this.name;
    this.dog.age = this.age;
    this.dogService.set(this.dog).subscribe(dog => this.dogs.push(dog));
  }


}
