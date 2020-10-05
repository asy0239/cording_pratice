package backjoon.oneLevel;

import java.util.Scanner;

public class Problem2884 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner sc = new Scanner(System.in);
		String[] x = sc.nextLine().split(" ");
		
		int hour = Integer.parseInt(x[0]);
		int min = Integer.parseInt(x[1]);
		if(min - 45 > 0 ) {
			System.out.println(hour + " " + (min-45));
		} else if (min - 45 < 0) {
			if(hour == 0) {
				System.out.println("23" + " " + (60+min-45));
			} else {
				System.out.println((hour-1)+ " " + (60+min-45));
			}
		} else {
			System.out.println(hour + " " + (min -45));
		}
	}

}
