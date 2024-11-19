import { Injectable, signal, WritableSignal } from "@angular/core";
import { User } from "../interfaces/case.interface";

@Injectable({
  providedIn: 'root',
})
export class UserService {
  // Signal to manage the current user
  private currentUserSignal: WritableSignal<User | null> = signal<User | null>(null);

  constructor() {
    // Initialize the user for example purposes
    this.setCurrentUser({ name: 'דני לוי' });
  }

  // Getter for the signal (using a function instead of ReadonlySignal)
  get currentUser(): User | null {
    return this.currentUserSignal();
  }

  // Function to set the current user
  setCurrentUser(user: User): void {
    console.log('CurrentUser: ', user)
    this.currentUserSignal.set(user);
  }

  // Function to clear the current user (logout)
  clearCurrentUser(): void {
    this.currentUserSignal.set(null);
  }
}
