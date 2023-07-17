import { Component } from '@angular/core';

import { CommonModule } from '@angular/common';

import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './componets/header.componet';


 

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    imports: [CommonModule, RouterOutlet, HeaderComponent]
})

export class AppComponent {

  title = 'Intro to Programming';

  favoritecolor = 'Blue';

}
