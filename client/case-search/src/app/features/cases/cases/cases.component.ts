import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchBarComponent } from '../search-bar/search-bar.component';
import { CaseListComponent } from '../case-list/case-list.component';
import { SearchService } from '../../../services/search.service';

import { FormsModule } from '@angular/forms';
import { UserService } from '../../../services/user.service';
import { Case } from '../../../interfaces/user.interface';


@Component({
  selector: 'app-cases',
  standalone: true,
  imports: [CommonModule, FormsModule, SearchBarComponent, CaseListComponent],
  templateUrl: './cases.component.html',
  styleUrls: ['./cases.component.scss'],
})
export class CasesComponent {
  cases: Case[] = [];
  filteredCases: Case[] = [];
  filteredCount: number = 0;
  sortField: string = 'caseId';

  constructor(private searchService: SearchService, private userService: UserService) {
    this.fetchCases();
  }

  // Fetch all cases from the service
  fetchCases(): void {
    this.cases = this.searchService.getCases();
    this.filteredCases = [...this.cases];
    this.filteredCount = this.filteredCases.length;
  }

  // Handle search input from SearchBarComponent
  onSearch(searchTerm: string): void {
    this.filteredCases = this.cases.filter(
      (c) =>
        c.title.includes(searchTerm) ||
        c.caseId.toString().includes(searchTerm)
    );
    this.filteredCount = this.filteredCases.length;
  }

  // Handle status filter from SearchBarComponent
  onFilterStatus(status: string): void {
    if (status === 'My Cases') {
      const currentUser = this.userService.currentUser;
      
      if (!currentUser) {
        this.filteredCases = [];
        this.filteredCount = 0;
        return;
      }
      const currentChairperson = currentUser.name;  
      console.log('my name is:', currentChairperson)    
      this.filteredCases = this.cases.filter((c) => c.chairperson === currentChairperson);
    }else {
      if (status === 'All') {
        this.filteredCases = [...this.cases];
      } else {
        this.filteredCases = this.cases.filter((c) => c.status === status);
      }
    }
    
    this.filteredCount = this.filteredCases.length;
  }

  // Handle sorting dropdown change
  onSortChange(event: Event): void {
    const target = event.target as HTMLSelectElement; // Ensure target is a select element
    if (target && target.value) {
      this.sortField = target.value;
      this.onSort(this.sortField); // Call sort logic
    }
  }

  // Handle sorting logic
  onSort(field: string): void {
    if (field === 'dateOpened') {
      this.filteredCases.sort(
        (a, b) =>
          new Date(a.dateOpened).getTime() - new Date(b.dateOpened).getTime()
      );
    } else if (field === 'caseId') {
      this.filteredCases.sort((a, b) => a.caseId - b.caseId);
    }
  }
}
