import { Component, OnInit } from '@angular/core';
import { AccountService } from './account.service';
import { Account, Role } from './account';

@Component({
  selector: 'app-adminpage',
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.css']
})
export class AdminpageComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  accounts: Account[];
  roles: string[] = ['Admin', 'User', 'UnusualUser'];
  email: string;
  password: string;
  changeRole: string;
  role: string;

  ngOnInit() {
    this.accountService.get().subscribe(data => {
      this.accounts = data;
    });
  }

  onDelete(id: number) {
    this.accountService.delete(id).subscribe(() => {
      this.accounts = this.accounts.filter(acc => acc.id !== id);
    });
  }

  isAdminAccount(account: Account): boolean {
    return (account.role == Role.Admin);
  }

  onEditingRole(id: number) {
    this.accounts.map(item => { item.id === id ? item.isEditingRole = true : null });
  }

  cancelEditingRole(id: number) {
    this.accounts.map(item => { item.id === id ? item.isEditingRole = false : null });
  }

  onSubmit() {
    if (this.role === "") return;
    this.accountService.create(this.email, this.password, this.roles.indexOf(this.role)).subscribe(account => {
      this.accounts.push(account);
    });
  }

  onChangeRole(id: number) {
    if (this.changeRole === "") return;
    this.accountService.changeRole(id, this.roles.indexOf(this.changeRole)).subscribe(changedAcc => {
      this.accounts.forEach(acc => acc.id === changedAcc.id ? acc.role = changedAcc.role : null);
    });
    this.cancelEditingRole(id);
  }
}
