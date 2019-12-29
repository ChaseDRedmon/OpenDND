import client from '@/services/ApiClientBase'
import AuthHeader from '@/helpers/authHeader'
import { AxiosPromise, AxiosResponse } from 'axios'

export default class UserService {
  // Submit an HTTP POST request to the backend asp.net core application server
  // We are submitting the ILogin data model
  public static async Login (username: string, password: string): Promise<void> {
    console.log('executing login on vueapp')

    client({
      method: 'POST',
      url: 'login',
      xsrfHeaderName: 'X-XSRF-TOKEN',
      headers: { 'Content-Type': 'application/json' },
      data: JSON.stringify({ username, password })
    })
      .then(this.HandleResponse)
      .then(function (user) {
        console.log(user)
        if (user.token) {
          localStorage.setItem('user', JSON.stringify(user))
        }
        return user
      }).catch(function (error) {
        console.log(error)
      })
  }

  // Submit an HTTP POST request to the backend asp.net core application server
  // We are submitting the ILogin data model
  public static async Logout (): Promise<void> {
    localStorage.removeItem('user')
  }

  public static async Register (user: any): Promise<void> {
    client({
      method: 'POST',
      url: 'register',
      xsrfHeaderName: 'X-XSRF-TOKEN',
      headers: { 'Content-Type': 'application/json' },
      data: JSON.stringify(user)
    })
      .then(this.HandleResponse)
  }

  public static async GetAll (): Promise<void> {
    client({
      method: 'GET',
      url: 'users',
      xsrfHeaderName: 'X-XSRF-TOKEN',
      headers: { AuthHeader, 'Content-Type': 'application/json' }
    })
  }

  public static async Update (User: string): Promise<void> {
    client({
      method: 'PUT',
      url: 'update',
      xsrfHeaderName: 'X-XSRF-TOKEN',
      headers: { AuthHeader, 'Content-Type': 'application/json' },
      data: JSON.stringify(User)
    })
      .then(this.HandleResponse)
  }

  public static async Delete (id: number): Promise<void> {
    // TODO: Add in ID support to this function and the respective code in the controller
    client({
      method: 'DELETE',
      url: 'delete',
      xsrfHeaderName: 'X-XSRF-TOKEN',
      headers: AuthHeader
    })
    // .then(this.HandleResponse)
  }

  public static async HandleResponse (response: AxiosResponse) {
    if (response.status === 401) {
      this.Logout()
      location.reload()
    }

    if (response.status !== 200) {
      const error = (response.data && response.data.message) || response.statusText
      return Promise.reject(error)
    }

    return response.data
  }
}
