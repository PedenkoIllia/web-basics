export interface Account {

  id: number;
  email: string;
  password: string;
  role: Role;
  isEditingRole: boolean;
}

export enum Role {
  Admin,
  User,
  UnusualUser
}
