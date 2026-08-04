using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Moble_Proj01
{
    public class sql
    {
        public static void RunSqlTest()
        {
            Map_View view = new Map_View();

            // 1. MySQL 접속 정보 설정 (본인 DB 비밀번호 '1111' 입력 상태)
            string connection_String = "Server=localhost;Database=sakila;Uid=root;Pwd=1111;";

            // 2. 실행할 SQL 쿼리문 (순서: 변수 선언이 먼저 와야 합니다)
            string sqlQuery = "SELECT customer_id, first_name, email FROM customer WHERE address_id < 200 LIMIT 3;";

            // 3. DB 연결 객체 생성
            using (MySqlConnection conn = new MySqlConnection(connection_String))
            {
                try
                {
                    conn.Open(); // DB 문 열기

                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // 4. 반복문으로 한 행씩 결과 읽어오기
                        while (reader.Read())
                        {
                            string? id = reader["customer_id"].ToString();
                            string? name = reader["first_name"].ToString();
                            string? email = reader["email"].ToString();


                            view.textBox1.Text = id + "\n";
                            view.textBox1.Text = name + "\n";
                            view.textBox1.Text = email + "\n";


                            MessageBox.Show($"고객ID: {id}\n이름: {name}\n이메일: {email}", "DB 데이터 조회 성공");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("에러 발생: " + ex.Message, "오류 안내");
                }
            }
        }
    }
}
