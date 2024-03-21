using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student
{
    public string sName;
    public string email;

    public Student(string name, string email)
    {
        sName = name;
        this.email = email;
    }
}
// SetValueAsync() 를 통해 지정한 참조에 데이터를 저장하고 해당 경로의 기존 데이터로 변경하는 작업
// string, long, double, bool Dictionary<string, Object>, List<Object>

public class FirebaseExample2 : MonoBehaviour
{
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        StudentRegister("20211367", "NAME", "example@gmail.com");
    }
    
    /// <summary>
    /// 데이터 베이스에 학생 클래스에 대한 정보를 추가하는 코드
    /// </summary>
    /// <param name="_sID">학생 고유 식별 코드 (학번)</param>
    /// <param name="_sName">학생 이름</param>
    /// <param name="_email">학생 이메일 주소</param>
    private void StudentRegister(string _sID, string _sName, string _email)
    {
        // 1. 클래스에 대한 생성
        Student student = new Student(_sName, _email);

        // 2. 해당 클래스를 Json의 형태로 바꿔줌(string)
        string Student_json =JsonUtility.ToJson(student);

        // 3. 레퍼런스 값 설정
        reference.Child("students").Child(_sID).SetRawJsonValueAsync(Student_json);

        Debug.Log($"{_sID} / {_sName} / {_email}");
    }

    private void StudentUpdate(string _sID, string _sName)
    {
        reference.Child("students").Child(_sID).Child("student_name").SetValueAsync(_sName);
    }
}
