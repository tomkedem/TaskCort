import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: true, // Indicates this is a standalone component
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {
  title: string = 'חיפוש תיקים';
}
