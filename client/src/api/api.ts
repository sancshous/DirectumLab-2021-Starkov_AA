import {RoutePath} from "../routes";
import {history} from "../service/history";

export class Api {
  private readonly baseUrl: string;
  constructor(baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  private getHeaders() {
    return {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    };
  }

  private async http<T>(url: string, method: 'POST' | 'GET', body?: any, headers?: any): Promise<T | null> {
    try {
      const response = await fetch(`${this.baseUrl}/${url}`, {
        method: method,
        headers: {
          ...this.getHeaders(),
          ...headers
        },
        credentials: 'include',
        mode: 'cors',
        body:
          body &&
          JSON.stringify({
            ...body
          }),
      });

      if (response.ok) {
        return await response.json();
      }
      return null;
    }
    catch (e) {
      window.console.log(e);
      history.push(RoutePath.ERROR);
      return null;
    }
  }

  public async post<T>(url: string, body?: any, headers?: any): Promise<T | null> {
    return await this.http(url, 'POST', body, headers)
  }

  public async get<T>(url: string, headers?: any): Promise<T | null> {
    return await this.http(url, 'GET', null, headers);
  }
}
