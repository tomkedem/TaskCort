import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CasesComponent } from './features/cases/cases/cases.component';
import { HeaderComponent } from './features/header/header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CasesComponent, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'case-search';
}
