import client from './ApiClientBase';

export default class LoginService {

  // Submit an HTTP POST request to the backend asp.net core application server
  // We are submitting the ILogin data model
  public static async Login(data: ILogin): Promise<void> {
    await client.post('login', data);
  }

  public static async Logout(): Promise<void> {
    await client.post('logout');
  }
}
