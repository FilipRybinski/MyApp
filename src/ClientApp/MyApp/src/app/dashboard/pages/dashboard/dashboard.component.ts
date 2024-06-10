import { Component } from '@angular/core';
import { User } from '../../../../interfaces/account/user';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent {
  public displayedColumns: string[] = ['name', 'surname', 'email', 'action'];
  public dataSource: MatTableDataSource<User> = new MatTableDataSource<User>([
    {
      id: '1',
      email: 'hydrogen@example.com',
      username: 'hydrogen',
      name: 'Hydrogen',
      surname: 'H',
    },
    {
      id: '2',
      email: 'helium@example.com',
      username: 'helium',
      name: 'Helium',
      surname: 'He',
    },
    {
      id: '3',
      email: 'lithium@example.com',
      username: 'lithium',
      name: 'Lithium',
      surname: 'Li',
    },
    {
      id: '4',
      email: 'beryllium@example.com',
      username: 'beryllium',
      name: 'Beryllium',
      surname: 'Be',
    },
    {
      id: '5',
      email: 'boron@example.com',
      username: 'boron',
      name: 'Boron',
      surname: 'B',
    },
    {
      id: '6',
      email: 'carbon@example.com',
      username: 'carbon',
      name: 'Carbon',
      surname: 'C',
    },
    {
      id: '7',
      email: 'nitrogen@example.com',
      username: 'nitrogen',
      name: 'Nitrogen',
      surname: 'N',
    },
    {
      id: '8',
      email: 'oxygen@example.com',
      username: 'oxygen',
      name: 'Oxygen',
      surname: 'O',
    },
    {
      id: '9',
      email: 'fluorine@example.com',
      username: 'fluorine',
      name: 'Fluorine',
      surname: 'F',
    },
    {
      id: '10',
      email: 'neon@example.com',
      username: 'neon',
      name: 'Neon',
      surname: 'Ne',
    },
  ]);
  public clickedRows = new Set<User>();
}
