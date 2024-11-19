import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Case } from '../../../interfaces/user.interface';



@Component({
  selector: 'app-case-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './case-list.component.html',
  styleUrls: ['./case-list.component.scss'],
})
export class CaseListComponent {
  @Input() cases: Case[] = [];
}
