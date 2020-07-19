import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
