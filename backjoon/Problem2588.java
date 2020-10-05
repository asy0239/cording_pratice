package backjoon.oneLevel;

import java.util.Scanner;

public class Problem2588 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner sc = new Scanner(System.in);
		
		int x = sc.nextInt();
		int y = sc.nextInt();
		
		sc.close();
		
		String second = Integer.toString(y);
		char sec;
		int result = 0;
		for(int i = second.length()-1; i >= 0; i--) {
			sec = second.charAt(i);
			if(i == 1) {
				result += Character.getNumericValue(sec) * x * 10;
			} else if(i == 0) {
				result += Character.getNumericValue(sec) * x * 100;
			} else {
				result += Character.getNumericValue(sec) * x;				
			}
			System.out.println(Character.getNumericValue(sec) * x);
		}
		System.out.println(result);
	}

}
